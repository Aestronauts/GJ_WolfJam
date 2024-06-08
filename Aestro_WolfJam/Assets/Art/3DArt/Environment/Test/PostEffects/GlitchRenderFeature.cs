using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlitchRenderFeature : ScriptableRendererFeature {
    class CustomRenderPass : ScriptableRenderPass {

        private Settings settings;
        private FilteringSettings filteringSettings;
        private ProfilingSampler m_ProfilingSampler;

        private List<ShaderTagId> m_ShaderTagIdList = new List<ShaderTagId>();

        private RenderTargetHandle tempRT;

        public CustomRenderPass(Settings settings) {
            this.settings = settings;
            filteringSettings = new FilteringSettings(RenderQueueRange.opaque, settings.layerMask);
            m_ShaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
            m_ShaderTagIdList.Add(new ShaderTagId("UniversalForward"));
            m_ProfilingSampler = new ProfilingSampler("Glitch");
            tempRT.Init("_TempGlitch");
        }

        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) {
            // Setup temporary render texture
            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;
            cmd.GetTemporaryRT(tempRT.id, opaqueDesc, FilterMode.Bilinear);
            
            // Configure which render target we are drawing to
            ConfigureTarget(tempRT.Identifier());
            ConfigureClear(ClearFlag.Color, Color.clear);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) {
            CommandBuffer cmd = CommandBufferPool.Get();
            
            // Draw renderers to render target
            using (new ProfilingScope(cmd, m_ProfilingSampler)) {
                SortingCriteria sortingCriteria = renderingData.cameraData.defaultOpaqueSortFlags;
                DrawingSettings drawingSettings = CreateDrawingSettings(m_ShaderTagIdList, ref renderingData, sortingCriteria);
                drawingSettings.overrideMaterialPassIndex = 0;
                drawingSettings.overrideMaterial = settings.glitchMaterial;
                context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings);
            }

            // Blit tempRT to camera target, using blitMaterial
            cmd.Blit(tempRT.Identifier(), renderingData.cameraData.renderer.cameraColorTarget, settings.blitMaterial, 0);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd) {
            cmd.ReleaseTemporaryRT(tempRT.id);
        }
    }

    CustomRenderPass m_ScriptablePass;

    [System.Serializable]
    public class Settings {
        public RenderPassEvent renderPassEvent;
        public Material glitchMaterial;
        public Material blitMaterial;
        public LayerMask layerMask;
    }

    public Settings settings;

    public override void Create() {
        m_ScriptablePass = new CustomRenderPass(settings);
        m_ScriptablePass.renderPassEvent = settings.renderPassEvent;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}
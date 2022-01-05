Shader "MyShaders/URP/unlit/Example"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _BaseColor("Base Color", Color) = (1,1,1,1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            HLSLINCLUDE

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                

            CBUFFER_END

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_Normal);
            SAMPLER(sampler_Normal);

            struct VertexInput
            {
                float4 position : POSITION;
                half3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct VertexOutput
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                half3 normal : NORMAL;
            };

            ENDHLSL

            Pass
            {
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                VertexOutput vert(VertexInput i)
                {
                    VertexOutput o;
                    o.position = TransformObjectToHClip(i.position.xyz);
                    o.normal = TransformObjectToWorldNormal(i.normal);
                    o.uv = i.uv;
                    return o;
                }

                float4 frag(VertexOutput i) : SV_Target
                {
                    float4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                    baseTex.rgb = i.normal;
                    return baseTex;
                }

                ENDHLSL
            }
        }
}

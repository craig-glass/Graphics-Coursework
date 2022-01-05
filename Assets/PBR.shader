Shader "MyShaders/Lighting/PBR"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MetallicTex ("Metallic (R)", 2D) = "white" {}
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Bump("Bump", 2D) = "bump" {}
        _BumpAmount("Bump Amount", Range(0,10)) = 1
    }
        SubShader
        {
            Tags {"Queue" = "Geometry"}

            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            #pragma surface surf Standard 

            sampler2D _MetallicTex;
            half _Metallic;
            fixed4 _Color;
            sampler2D _Bump;
            half _BumpAmount;

            struct Input {
                float2 uv_MetallicTex;
                float2 uv_Bump;
                float2 viewDir;
            };

            void surf(Input IN, inout SurfaceOutputStandard o) {
                half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
                o.Albedo = _Color.rgb;
                o.Smoothness = tex2D(_MetallicTex, IN.uv_MetallicTex).r;
                o.Metallic = _Metallic;
                o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));
                o.Normal *= float3(_BumpAmount, _BumpAmount, 1);
                o.Normal *= rim > 0.2 ? rim : 0;

            }


        ENDCG
    }
    FallBack "Diffuse"
}

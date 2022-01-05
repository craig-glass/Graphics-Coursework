Shader "MyShaders/LogicalCutoffs"
{
    Properties
    {
        _RimColor ("Rim Color", Color) = (0,0.5,0.5,0)
        _RimColor2 ("Rim Color 2", Color) = (0,0.5,1,0)
        _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
        _RimPower2 ("Rim Power 2", Range(0.2, 10)) = 2
        _Tex ("Texture", 2D) = "white" {}
        _Bump ("Bump", 2D) = "bump" {}
        _BumpAmount("Bump Amount", Range(0,10)) = 1
        _StripeSize("Stripe Size", Range(0,10)) = 1
    }

    SubShader
    {
        

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        struct Input {
            float3 viewDir;
            float3 worldPos;
            float2 uv_Tex;
            float2 uv_Bump;
        };
        
        float4 _RimColor;
        float4 _RimColor2;
        float _RimPower;
        float _RimPower2;
        sampler2D _Tex;
        sampler2D _Bump;
        half _BumpAmount;
        half _StripeSize;

        void surf(Input IN, inout SurfaceOutput o) {
            half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = frac(IN.worldPos.y * _StripeSize * 0.5) > 0.4 ? _RimColor * rim * _RimPower: _RimColor2 * rim * _RimPower2;
            o.Albedo = tex2D(_Tex, IN.uv_Tex).rgb;
            o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));
            o.Normal *= float3(_BumpAmount, _BumpAmount,1);
        }

        ENDCG
    }
    FallBack "Diffuse"
}

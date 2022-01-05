Shader "MyShaders/Diffuse"
{
	Properties{
		_myDiffuseTexture ("Diffuse Texture", 2D) = "white" {}
		_myEmissionTexture ("Emission Texture", 2D) = "white" {}
	}

		SubShader
	{

		CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _myDiffuseTexture;
			sampler2D _myEmissionTexture;

			struct Input {
				float2 uv_myDiffuseTexture;
				float2 uv_myEmissionTexture;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
				o.Albedo = tex2D(_myDiffuseTexture, IN.uv_myDiffuseTexture).rgb;
				o.Emission = tex2D(_myEmissionTexture, IN.uv_myEmissionTexture).rgb;
			}
		ENDCG
	}

	Fallback "Diffuse"
}
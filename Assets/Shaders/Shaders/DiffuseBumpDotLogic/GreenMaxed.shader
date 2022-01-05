Shader "MyShaders/GreenMaxed"
{
	Properties 
	{
		_myTex ("Texture", 2D) = "white" {}
	}

		SubShader
	{
		CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _myTex;

			struct Input
			{
				float2 uv_myTex;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
				float3 tempColor = tex2D(_myTex, IN.uv_myTex).rgb;
				tempColor.g = 0.5;
				o.Albedo = tempColor;
				
			}

		ENDCG
	}

	Fallback "Diffuse"
}
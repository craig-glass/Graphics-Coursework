Shader "MyShaders/FirstShader" {

	Properties{
		_myColor ("Main Color", color) = (1,1,1,1)
		_myEmission ("Emission color", color) = (1,1,1,1)
		_myNormal ("Normal Color", color) = (1,1,1,1)
	}

		SubShader
	{

		CGPROGRAM
			#pragma surface surf Lambert

			struct Input {
				float2 uvMainTex;
			};

			fixed4 _myColor;
			fixed4 _myEmission;
			fixed4 _myNormal;

			void surf(Input IN, inout SurfaceOutput o) {
				o.Albedo = _myColor.rgb;
				o.Emission = _myEmission.rgb;
				o.Normal = _myNormal;
			}

		ENDCG
	}

	FallBack "Diffuse"

	
}
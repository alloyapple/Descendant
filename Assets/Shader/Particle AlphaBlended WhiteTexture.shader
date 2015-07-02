Shader "Particles/Alpha Blended (white texture)"
{
Properties
{
	_MainTex ("Particle Texture", 2D) = "white" {}
	//_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
	_Multiply ("Multiply", Range(0.1,8.0)) = 1.0
}

Category
{
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
	Cull Off Lighting Off ZWrite Off Fog {Mode Off  }
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;

			};
			
			float4 _MainTex_ST;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				return o;
			}

			sampler2D _CameraDepthTexture;
			float _InvFade;
			float _Multiply; 
			
			fixed4 frag (v2f i) : COLOR
			{

				
				_Multiply *= i.color.a;
				
				fixed prev = tex2D(_MainTex, i.texcoord).r;
				//return lerp(half4(i.color.rgb , 0), i.color + prev * i.color.a * _Multiply, prev * i.color.a);
				return lerp(half4(i.color.rgb , 0), i.color + prev * _Multiply, prev * i.color.a);
			}
			ENDCG 
		}
	}
}
}

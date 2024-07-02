Shader "Custom/FireShader"
{
        Properties
        {
            _MainTex("Texture", 2D) = "white" {}
            _NoiseTex("Noise Texture", 2D) = "white" {}
            _Speed("Speed", Float) = 1.0
            _Color("Color", Color) = (1, 1, 1, 1)
        }

            SubShader
            {
                Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
                Blend SrcAlpha OneMinusSrcAlpha
                LOD 100

                Pass
                {
                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag

                    #include "UnityCG.cginc"

                    struct appdata
                    {
                        float4 vertex : POSITION;
                        float2 uv : TEXCOORD0;
                    };

                    struct v2f
                    {
                        float2 uv : TEXCOORD0;
                        float4 vertex : SV_POSITION;
                    };

                    sampler2D _MainTex;
                    sampler2D _NoiseTex;
                    float _Speed;
                    float4 _Color;

                    v2f vert(appdata v)
                    {
                        v2f o;
                        float wave = sin(_Time.y * _Speed + v.vertex.x * 0.02) * 0.015;
                        v.vertex.x -= wave;
                        v.vertex.y += wave;
                        o.vertex = UnityObjectToClipPos(v.vertex);
                        o.uv = v.uv;
                        return o;
                    }

                    fixed4 frag(v2f i) : SV_Target
                    {
                        float2 uv = i.uv;
                        float2 offset = float2(uv.x, uv.y + _Time.w * _Speed);

                        fixed4 texColor = tex2D(_MainTex, uv);
                        float noise = tex2D(_NoiseTex, offset).r;

                        fixed4 finalColor = texColor * _Color * (noise * 0.5 + 0.5);

                        finalColor.a = 0.8;

                        return finalColor;
                    }
                    ENDCG
                }
            }
            FallBack "Mobile/Diffuse"
    }


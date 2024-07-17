Shader "Unlit/WheatShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        [PowerSlider(3.0)]
        _WindStrength("Wind Strength", Range(0.01, 1))
        [PowerSlider(3.0)]
        _Speed("Wind Speed", Range(0.01, 1))
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
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
                float4 _MainTex_ST;
                float _WindStrength;
                float _Speed;

                v2f vert(appdata v)
                {
                    v2f o;
                    // Смещение по оси X на основе синусоиды и времени
                    float wave = sin(v.vertex.y * 10.0 + _Time.y * _Speed) * 0.1 * _WindStrength;
                    v.vertex.x += wave;

                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}


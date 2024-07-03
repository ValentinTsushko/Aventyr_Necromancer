Shader "Custom/GrassWaveShader"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _WaveSpeed("Wave Speed", Range(0, 1)) = 0.1
        _WaveFrequency("Wave Frequency", Range(0, 1)) = 0.3
        _WaveIntensity("Wave Intensity", Range(0, 1)) = 0.1
        _WaveWidth("Wave Width", Range(0, 1)) = 0.1
        _SecondWaveWidth("Second Wave Width", Range(0, 1)) = 1.0
        _RandomSeed("Random Seed", Range(0, 1)) = 0.5
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
                float4 _Color;
                float _WaveSpeed;
                float _WaveFrequency;
                float _WaveIntensity;
                float _WaveWidth;
                float _SecondWaveWidth;
                float _RandomSeed;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                    // волна света
                    float wave = sin(i.uv.x + _Time.y * _WaveSpeed + i.uv.y * _WaveFrequency) * _WaveIntensity;

                    // ѕрименение ширины волны
                    wave *= smoothstep(0.0, _WaveWidth, 1.0 - abs(frac(_WaveFrequency * i.uv.x + _Time.y * _WaveSpeed) * 2.0 - _SecondWaveWidth));

                    col.rgb += wave;

                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}

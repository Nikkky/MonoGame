
matrix WorldViewProjection;
float Transparency = 0.5;

struct VertexShaderInput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
};

VertexShaderOutput MainVS(in VertexShaderInput input)
{
	VertexShaderOutput output = (VertexShaderOutput)0;

	output.Position = input.Position;
	output.Color = input.Color;
	
	return output;
}


float4 MainPS(VertexShaderOutput input) : COLOR
{
	
	float3 color = (color.rgb * color.a) + (color.rgb * (1 - color.a));
    color.a = Transparency;
	return input.Color;
}

technique Basic
{
    pass Pass0
    {
        AlphaBlendEnable = TRUE;
        DestBlend = INVSRCALPHA;
        SrcBlend = SRCALPHA;
        VertexShader = compile vs_4_0 MainVS();
        PixelShader = compile ps_4_0 MainPS();
    }
}
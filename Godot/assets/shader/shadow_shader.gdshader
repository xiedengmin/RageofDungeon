shader_type canvas_item;

uniform float tilt = 0.4;
uniform float scale = 0.3;
uniform float alpha = 0.4;
uniform bool shadow = true;

void fragment(){
	vec4 previous_color = texture(TEXTURE,UV);
	vec4 block_color;
	if(shadow == true){
		block_color = vec4(0.0,0.0,0.0,previous_color.a * alpha);
	}else{
		block_color = vec4(previous_color.r,previous_color.g,previous_color.b,previous_color.a * alpha);
	}

    COLOR = block_color;
}

void vertex(){
	mat3 mat_scale = mat3(vec3(1.0,0.0,0.0),vec3(0.0,1.0,0.0),vec3(0.0,0.0,1.0));
	mat3 mat_tilt = mat3(vec3(1.0, tilt, 0.0), vec3(0.0, scale, 0.0), vec3(0.0, 0.0, 1.0));
	mat3 mul = mat_scale * mat_tilt;
	vec3 temp = vec3(VERTEX,0.0) * mul;
	
	VERTEX =  temp.xy;
}
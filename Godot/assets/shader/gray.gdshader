shader_type canvas_item;

uniform bool is_gray = true;

void fragment(){
	
	vec4 sprite_color = texture(TEXTURE,UV);
	vec4 gray_color;
	if(is_gray == true){
		float gray_temp = dot(sprite_color.rgb,vec3(0.2126,0.7152,0.0722));
		gray_color = vec4(gray_temp,gray_temp,gray_temp,sprite_color.a);
	}else{
		gray_color = sprite_color;
	}
	COLOR = gray_color;
}
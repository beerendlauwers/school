function veranderDropdown(imagenaam)
{
	var image = document.getElementById(imagenaam).src;
	var pos = image.indexOf("/images/");
	
	var beginpart = image.substring( 0, pos );
	
	if( pos >= 0 )
	{
		image = image.substring( pos, image.length );
	}
	
	if(image=='/images/add.png')
	{
		document.getElementById(imagenaam).src= beginpart + '/images/minus.png'
	}
	
	if(image=='/images/minus.png')
	{
		document.getElementById(imagenaam).src= beginpart + '/images/add.png'
	}
}
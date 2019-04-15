function isEven(choice)
{
	if(choice % 2 === 0)
	{
		return true;
	}return false;
}

function factorial(facto)
{
	var wynik = 1;
	if(facto <= 1){
		return 1;
	}
	while(facto > 0)
	{
		wynik *= facto;
		facto--;
	}
	return wynik;
}

function kebabToSnake(toReplace)
{
	for(var i = 0;i<toReplace.length;i++)
{
	if(toReplace[i] == '-')
	{
	var newStr = toReplace.replace(/-/g, "_");
	}
	
}
	return newStr;
}
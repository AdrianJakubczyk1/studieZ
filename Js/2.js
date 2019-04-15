var age = prompt("whats you age");
if(age < 0){
	alert("wrong");

}else if(age == 21){
	alert("happy birthday");
}else if((age % 2)>0 ){
	alert("yours age is odd");
}else if(age % Math.sqrt(age) === 0)
{
	alert("perfect square!");
}
else{
	alert("..... ");
}
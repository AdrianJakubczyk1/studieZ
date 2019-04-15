var secretNumber = Math.random(1) * 1;
console.log(secretNumber);
var guess = prompt("guess the number");
Number(guess);
if(guess === secretNumber){
	alert("gotcha");
}else{
	alert("you are wrong");
}
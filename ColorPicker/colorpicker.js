var colors = generateRandomColors(6);
var squares = document.querySelectorAll(".square")
var goal = randomF();
var colorDisplay = document.getElementById("colorDisplay");
var message= document.querySelector("#message");
var h1 = document.querySelector("h1");
var resetButton = document.querySelector("#reset");
var easyButton=document.querySelector("#easyBtn");
var hardButton=document.querySelector("#hardBtn");
var numberOfS = 6;
var total = 0;

easyBtn.addEventListener("click", function(){
	easyBtn.classList.add("selected");
	hardBtn.classList.remove("selected");
	numberOfS = 3;
	colors = generateRandomColors(numberOfS);
	//get random color as new goal
	goal = randomF();
	//display it
	colorDisplay.textContent=goal;
	for(var i = 0; i<squares.length;i++){//update squares
		if(colors[i]){
		squares[i].style.backgroundColor = colors[i];}else{
		squares[i].style.display = "none";
	}
}
})

hardBtn.addEventListener("click", function(){
	easyBtn.classList.remove("selected");
	hardBtn.classList.add("selected");
	numberOfS = 6;
	colors = generateRandomColors(numberOfS);
	goal = randomF();
	//display it
	colorDisplay.textContent=goal;
	for(var i = 0; i<squares.length;i++){//update squares
		if(colors[i]){
		squares[i].style.backgroundColor = colors[i];
		squares[i].style.display = "block";
}
}
})

resetButton.addEventListener("click", function(){
	//random  new colors
	colors = generateRandomColors(numberOfS);
	//get random color as new goal
	goal = randomF();
	//display it
	colorDisplay.textContent=goal;

	for(var i = 0; i<squares.length;i++){//update squares
	squares[i].style.backgroundColor = colors[i];
	h1.style.backgroundColor="steelblue"
	message.textContent=" ";
	this.textContent = "new Colors"
}
})

for(var i = 0; i<squares.length;i++){
	squares[i].style.backgroundColor = colors[i];
	squares[i].addEventListener("click", function(){

		var clickedColor = this.style.backgroundColor;
		console.log(clickedColor);
		console.log(goal);
		if(clickedColor === goal){
			message.textContent="gotcha well done!";
			change(clickedColor);
			h1.style.backgroundColor=goal;
			resetButton.textContent = "Play again? x)"
			

		}else{
			this.style.backgroundColor = "#232323";
			message.textContent="try again"
		
		}

	})
}


colorDisplay.textContent = goal;

function change(color){
	for(var i = 0; i<squares.length;i++){
		squares[i].style.backgroundColor = color;
}
}

function randomF()
{
	var random = Math.floor(Math.random()*colors.length);
	return colors[random];

}

function generateRandomColors(num){
	var array = [];
	for(var i = 0; i< num ; i++){
		array.push(randomColor());
	}
	return array;
}

function randomColor(){
	
var red = Math.floor(Math.random()*256);
var green = Math.floor(Math.random()*256);
var blue = Math.floor(Math.random()*256);

return "rgb(" + red +", "+ green+", "+ blue+")";
}



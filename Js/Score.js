var count = 0;
var count2 = 0;
var overall = document.querySelector("input")
var first = document.querySelector("#one");
var second = document.querySelector("#two");
var reset = document.querySelector("#reset");
var text = document.querySelector("h1");
var head3 = document.querySelector("h3")
var p1 = document.querySelector("#p1Dis");
var p2 = document.querySelector("#p2Dis");
var check = true;
var scores = 5;
var winDis=document.querySelector("p span")
first.addEventListener("click", function(){
	
	if(count == scores){
		p1.classList.add("winner");
		p1.textContent=count;	
		check=false;}
		if(check)	{count++; p1.textContent=count;	 }
		
	// text.textContent=count1 + " to " + count2;
})
second.addEventListener("click", function(){

	if(count2 == scores){
		p2.classList.add("winner");
		p2.textContent=count2;	
		check=false;}
		if(check){
			count2++;
	p2.textContent=count2;		}

	
})
reset.addEventListener("click", function(){
	resetZ();
})

overall.addEventListener("change", function(){
	winDis.textContent = overall.value;
	scores = overall.value;
	resetZ();
})
function resetZ()
{
		count = 0;
	count2 = 0;
	p1.textContent=count;	
		p2.textContent=count2;	
		p1.classList.remove("winner");
		p2.classList.remove("winner");
		check = true;
}

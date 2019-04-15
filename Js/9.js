window.setTimeout(function() {
  var todo = [];
while(input !== "quit"){
  var input = prompt("what you would like to do");

  if(input === "list"){
  	console.log("***********");
  	todo.forEach(function(todo, i)
  	{
  			console.log(i +" : " + todo);
  	})
  console.log("***********");
  }
 	else if(input === "new")
 	{
 		var newTodo = prompt("Enter new Todo");
 		todo.push(newTodo);

 	}else if(input === "delete")
 	{
 	var index=	prompt("enter index");
 		todo.splice(index, 1);
 	}
 }
}, 500);
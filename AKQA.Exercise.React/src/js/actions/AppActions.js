import dispatcher from "../dispatcher";

export function updateName(name){

    fetch('/home/PostUsername', {
	    method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
	    body: JSON.stringify({
	    	username : name
	    })
	}).then(response => response.json())
    .then((responseJson) => {
    	console.log(responseJson);
		dispatcher.dispatch({
			type: "UPDATE_NAME",
			name,
			responseJson
		});    	
    })
    .catch((error) => {
        console.error(error);
    });
}

export function updateNumber(number){
	fetch('/home/PostNumberWord', {
	    method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
	    body: JSON.stringify({
	    	number : number
	    })
	}).then(response => response.json())
    .then((responseJson) => {
    	console.log(responseJson);
		dispatcher.dispatch({
			type: "UPDATE_NUMBER",
			number,
			responseJson
		});
    })
    .catch((error) => {
        console.error(error);
    });
}
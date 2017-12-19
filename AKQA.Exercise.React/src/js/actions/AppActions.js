import dispatcher from "../dispatcher";

export function updateName(name){
	fetch('/home/GetUsername?username=' + encodeURIComponent(name)
	).then(response => response.json())
    .then((responseJson) => {
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
	fetch('/home/GetNumberWord?number=' + number
	).then(response => response.json())
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
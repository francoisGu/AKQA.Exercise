import { EventEmitter } from "events";
import dispatcher from "../dispatcher";

class AppStore extends EventEmitter {
	constructor() {
		super();
		this.username = "";
		this.Username = "";
		this.number = 0;
		this.NumberWords = "ZERO DOLLAR";
	}

	getName(){
		return this.Username;
	}

	getNumberWords(){
		return this.NumberWords;
	}

	getNumber(){
		return this.number;
	}

	updateName(input, name){
		this.username = input;
		this.Username = name;
		this.emit("name_change");
	}

	updateNumber(input, numberWords){
		this.number = input;
		this.NumberWords = numberWords;
		this.emit("number_change");
	}

	handleActions(action) {
		switch(action.type) {
			case "UPDATE_NAME": {
				this.updateName(action.name, action.responseJson);
				break;
			}
			case "UPDATE_NUMBER": {
				this.updateNumber(action.number, action.responseJson);
				break;
			}
		}
	}
}

const appStore = new AppStore;
dispatcher.register(appStore.handleActions.bind(appStore));
export default appStore;
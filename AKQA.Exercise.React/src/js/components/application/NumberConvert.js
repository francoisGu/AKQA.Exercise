import React from "react";
import * as AppActions from "../../actions/AppActions";
import AppStore from "../../stores/AppStore";

export default class NumberConvert extends React.Component {
	constructor(){
		super();
		this.getNumber = this.getNumber.bind(this);
		this.setNumber = this.setNumber.bind(this);
		this.state = {
			number: 0,
			numberWords: AppStore.getNumberWords()
		};
	};

	componentWillMount() {
		AppStore.on("number_change", this.getNumber);
	}

	componentWillUnmount() {
		AppStore.removeListener("number_change", this.getNumber);
	}

	getNumber(){
		this.setState({
			number : AppStore.getNumber(),
			numberWords: AppStore.getNumberWords(),
		});
	}

	setNumber(event){
		console.log(event.target.value);
		AppActions.updateNumber(event.target.value);
	}

	render(){
		return(
			<div>
		      <form class="" onSubmit={this.setNumber}>
		      	<div class="form-group row">
		      		<div class="col-xs-2 col-xl-2 col-lg-2 col-md-2 col-sm-2 text-center">
		      		<label>Number:</label>
		      		</div>
			        
			        <div class="col-xs-6 col-xl-6 col-lg-6 col-md-6 col-sm-6 text-center">
			        <input class="form-control" type="number" value={this.state.number} onChange={this.setNumber} />
			        </div>
		        
		        </div>
		      </form>
		      <br/>

		      <div class="row">
		      	<div class="col-xs-2 col-xl-2 col-lg-2 col-md-2 col-sm-2 text-center">
		      		<span><b>Number Output: </b></span> 
	      		</div>
	      		<div class="col-xs-6 col-xl-6 col-lg-6 col-md-6 col-sm-6">
	      		{this.state.numberWords}
	      		</div>

		      </div>

		    </div>
			);
	}

}
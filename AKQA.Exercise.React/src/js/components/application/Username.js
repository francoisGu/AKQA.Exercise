import React from "react";
import * as AppActions from "../../actions/AppActions";
import AppStore from "../../stores/AppStore";

export default class Username extends React.Component {
	constructor(){
		super();
		this.getName = this.getName.bind(this);
		this.setName = this.setName.bind(this);
		this.state = {
			name: AppStore.getName()
		};
	};

	componentWillMount() {
		AppStore.on("name_change", this.getName);
	}

	componentWillUnmount() {
		AppStore.removeListener("name_change", this.getName);
	}

	getName(){
		this.setState({
			name: AppStore.getName(),
		});
	}

	setName(event){
		AppActions.updateName(event.target.value);
	}

	render(){
		return(
			<div>
		      <form class="" onSubmit={this.setName}>
		      	<div class="form-group row">
		      		<div class="col-xs-2 col-xl-2 col-lg-2 col-md-2 col-sm-2 text-center">
		      		<label>Name:</label>
		      		</div>
			        
			        <div class="col-xs-6 col-xl-6 col-lg-6 col-md-6 col-sm-6 text-center">
			        <input class="form-control" type="text" value={this.state.name} onChange={this.setName} />
			        </div>	        
		        </div>
		      </form>
		      <br/>

		      <div class="row">
		      	<div class="col-xs-2 col-xl-2 col-lg-2 col-md-2 col-sm-2 text-center">
		      		<span><b>Name Output: </b></span> 
	      		</div>
	      		<div class="col-xs-6 col-xl-6 col-lg-6 col-md-6 col-sm-6">
	      		{this.state.name}
	      		</div>

		      </div>

		    </div>
			);
	}

}
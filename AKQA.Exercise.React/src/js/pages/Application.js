import React from "react";

import Username from "../components/application/Username";
import NumberConvert from "../components/application/NumberConvert";

export default class Calculator extends React.Component {
	render() {
		const containerStyle = {
      		marginTop: "20px"
    	};
		return (
			<div class="col-lg-12">
				<h1>Application</h1>
				<div class="col-lg-12" style={containerStyle}>
					<Username />
				</div>
				<hr class="col-lg-12"/>
				<div class="col-lg-12" style={containerStyle}>
					<NumberConvert />
				</div>
			</div>
		);
	}
}

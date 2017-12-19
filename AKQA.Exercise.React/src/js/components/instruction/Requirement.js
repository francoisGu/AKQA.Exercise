import React from "react";

export default class Requirement extends React.Component {
	render(){
		return(
			<div class="row">
				<h4>Requirement</h4>
	  			<div class="col-lg-12">
	  				
					<ol>
					  <li>A solution that can be executed by simply opening the solution file, and
						running Debug - Start Debugging (or F5) from Visual Studio.
						Provide any documentation if additional steps to install or execute are
						required.</li>
					  <li>Well documented code.</li>
					  <li>Well documented Unit Test(s) that provide 100% unit test coverage of all
						services built. You can use any unit testing framework you feel
						comfortable. eg. nUnit, MSTest, xUnit.</li>
					  <li>Details of applications, frameworks etc. required to run your
						solution, Technical description and explanation of design and
						programming techniques utilised</li>
					</ol>		
	  				<br/>		
	  			</div>
			</div> 			
		);
	}
}

// export default Requirement;
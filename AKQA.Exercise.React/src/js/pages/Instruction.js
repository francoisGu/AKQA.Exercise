import React from "react";

import Requirement from "../components/instruction/Requirement";
import Assumption from "../components/instruction/Assumption";

export default class Instruction extends React.Component {
  render() {
    return (
      <div>
        <h1>Instruction</h1>
        <div class="col-lg-12">
          <Requirement/>
	        <Assumption/>
        </div>	      
      </div>
    );
  }
}

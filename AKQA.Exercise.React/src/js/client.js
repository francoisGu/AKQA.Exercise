import React from "react";
import ReactDOM from "react-dom";
import { Router, Route, IndexRoute, hashHistory } from "react-router";

import Layout from "./pages/Layout";
import Instruction from "./pages/Instruction";
import Application from "./pages/Application";

const app = document.getElementById('app');

ReactDOM.render(
  <Router history={hashHistory}>
    <Route path="/" component={Layout}>
      <IndexRoute component={Instruction}></IndexRoute>
      <Route path="Application" component={Application}></Route>
    </Route>
  </Router>,
app);

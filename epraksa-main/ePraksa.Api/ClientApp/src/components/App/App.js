import React from "react";
import Home from "../Home/Home";
import Mentors from '../Mentors/Mentors'
import PrivateRoute from "../Router/PrivateRouter";
import { Route } from 'react-router';
import Profile from '../Profile/Profile';


const App = () => {
 
  return (
    <div>
    <Route exact path="/" component={Home} />

    {/* <PrivateRoute path="/home" component={Home} />
    <PrivateRoute path="/mentors" component={Mentors} /> */}
    <Route path="/home" component={Home} />
    <Route path="/mentors" component={Mentors} />
    <Route path="/profile" component={Profile} />
    
    </div>
   
  );
};
export default App;


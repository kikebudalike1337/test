import React from "react";
import { Route, Redirect } from "react-router-dom";
import { useSelector } from "react-redux";

const PrivateRoute = ({ component: Component, ...rest }) => {
    
  const { student } = useSelector(state => state);
  const isAuth =student.isAuthenticated;
  console.log(student)
  console.log(isAuth)
  return (
    <Route
      {...rest}
      render={(props) =>
        isAuth ? <Component {...props} /> : <Redirect to="/" />
      }
    />
  );
  
};

export default PrivateRoute;

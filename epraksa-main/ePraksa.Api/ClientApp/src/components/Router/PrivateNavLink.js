import React from "react";
import { NavLink } from "react-router-dom";
import { useSelector } from "react-redux";

const PrivateNavLink = ({ ...rest }) => {
    
  const { student } = useSelector((state) => state);
  const isAuth =student.isAuthenticated;
  console.log(isAuth)
  if (!isAuth) return null;
  return <NavLink {...rest} />;
  
};

export default PrivateNavLink;
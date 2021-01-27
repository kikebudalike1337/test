import React from "react";
import styles from "./Login.module.css";
import { useForm } from "react-hook-form";
import axios from "axios";
import jwtDecode from "jwt-decode";
import setAuthorizhationToken from '../../utils/SetAuthorizathion';
import { SET_CURRENT_USER } from "../../redux/actions/students";
import { useDispatch } from "react-redux";



const Login = ({props}) => {
  const { register, handleSubmit } = useForm();
  const dispatch=useDispatch();
 const setCurrentUser=(student)=>{
return{
  type:SET_CURRENT_USER,
  student
};
 }
  const onSubmit = (e) => {
    axios
      .post("/api/User/Login", e)
      .then((res) => {
        console.log(res.data.token)
        localStorage.setItem('jwtToken', res.data.token);
        setAuthorizhationToken(res.data.token);
        dispatch(setCurrentUser(jwtDecode(res.data.token)));
       
       
      })
      .catch((err) => {
        alert("Netočno uneseni podaci")
      });
  };
  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <input
          className={styles.Username}
          name="username"
          ref={register}
          placeholder="Username"
        ></input>
        <input
          className={styles.Password}
          type="password"
          name="password"
          ref={register}
          placeholder="Password"
        ></input>
        <button className={styles.LoginBtn}>Login</button>
      </form>
    </div>
  );
};

export default Login;

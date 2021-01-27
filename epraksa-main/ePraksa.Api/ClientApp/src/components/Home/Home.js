import React from "react";
import Header from "../Header/Header";
import Login from "../Login/Login";
import Students from "../Students/Students"
import styles from "./Home.module.css";
import { useSelector } from "react-redux";

const Home = (props) => {
    const { student } = useSelector((state) => state);
    const isAuth = student.isAuthenticated;
    return (
        <>
            <Header />
            <Login />
            {/*isAuth ? <Students /> : <Login /> */}
        </>
    );
};

export default Home;

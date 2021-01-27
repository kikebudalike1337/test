import React from "react";
import styles from "./Header.module.css";
import PrivateNavLink from "../Router/PrivateNavLink";
import {
    Link
} from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";
import { setCurrentUser } from "../../redux/actions";

const Header = () => {
    const dispatch = useDispatch();
    const { student } = useSelector((state) => state);
    const isAuth = student.isAuthenticated;
    const handleLogout = () => {
        dispatch(setCurrentUser({ isAuthenticated: false, student: '' }));
    };

    return (
        <div className={styles.Navigation}>
            <div className={styles.Logo}>e-Praksa</div>
            <div>
                <PrivateNavLink to="/" className={styles.students}>
                    Studenti
        </PrivateNavLink>
                <br></br>
                <PrivateNavLink to="/mentors" className={styles.mentors}>
                    Mentori
        </PrivateNavLink>
                {isAuth ? (
                    <div className={styles.logoutGroup}>
                        <h4 className={styles.username}>Hello, {student.student.role}!</h4>
                        <button className={styles.button} onClick={handleLogout}>
                            Logout
                        </button>
                    </div>
                ) : null}
                <Link className={styles.profile}  to="/profile" >
                    Profile
                </Link>
            </div>
        </div>
    );
};

export default Header;

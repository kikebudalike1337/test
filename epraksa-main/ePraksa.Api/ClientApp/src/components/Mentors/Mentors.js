import React from 'react';
import styles from './Mentors.module.css';
import Header from "../Header/Header";


function Mentors() {
    return (
        <>
        <div><Header/></div>
        <div className = {styles.list}>
            Lista Mentora
        </div>
        </>
    )
}

export default Mentors

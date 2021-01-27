import React, { useEffect, useState } from 'react';
import styles from "./Profile.module.css";
import Header from "../Header/Header";
import { Paper, Typography } from '@material-ui/core';
import axios from 'axios';

const Profile = () => {

    const [user, setUser] = useState();

    const fetchUser = async () => {
        const { data } = await axios.get('https://localhost:5001/api/Students/2');
        console.log(data)
        setUser(data);
    }

    useEffect(() => fetchUser(), []);

    return (
        <>
            <Header />
            <Paper elevation={3} className={styles.paper}>
                <Typography variant='h4' children={'Korisnicki Podaci:'} />
                <div className={styles.dataFieldWrapper}>
                    <Typography variant='h6' className={styles.dataFieldTitle}>
                        User ID:
                </Typography>
                    <div className={styles.dataFieldContent}>{user?.userID ? user.userID : '...'}</div>
                </div>
                <div className={styles.dataFieldWrapper}>
                    <Typography variant='h6' className={styles.dataFieldTitle}>
                        Ime:
                </Typography>
                    <div className={styles.dataFieldContent}>{user?.firstName ? user.firstName : '...'}</div>
                </div>
                <div className={styles.dataFieldWrapper}>
                    <Typography variant='h6' className={styles.dataFieldTitle}>
                        Prezime:
                </Typography>
                    <div className={styles.dataFieldContent}>{user?.lastName ? user.lastName : '...'}</div>
                </div>
                <div className={styles.dataFieldWrapper}>
                    <Typography variant='h6' className={styles.dataFieldTitle}>
                        E-mail:
                </Typography>
                    <div className={styles.dataFieldContent}>{user?.email ? user.email : '...'}</div>
                </div>
                <div className={styles.dataFieldWrapper}>
                    <Typography variant='h6' className={styles.dataFieldTitle}>
                        Kontakt:
                </Typography>
                    <div className={styles.dataFieldContent}>{user?.phoneNumber ? user.phoneNumber : '...'}</div>
                </div>
            </Paper>

        </>
    )
}

export default Profile;

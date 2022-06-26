import React, { useRef, useState, useEffect, useContext } from 'react';
import { Link } from "react-router-dom";
import AuthContext from "../Context/AuthProvider";

import axios from '../../Services/axios';
const LOGIN_URL = '/login';

const Login = () => {
    const { setAuth } = useContext(AuthContext);
    
    const userRef = useRef();
    const errRef = useRef();

    const [userEmail, setUserEmail] = useState('');
    const [userPassword, setUserPassword] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);//

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [userEmail, userPassword])

    const handleSubmit = async (e) => {
        e.preventDefault();

        // const LOGIN_URL = '/login';
        // const BASE_URL = 'http://localhost:54620';
        try {
            const response = await axios.post(LOGIN_URL,
                JSON.stringify({ userEmail, userPassword }),
                {
                    headers: { 'Content-Type': 'application/json' },
                    withCredentials: true
                }
            );
            console.log(JSON.stringify(response?.data));
            //console.log(JSON.stringify(response));
            const accessToken = response?.data?.accessToken;
            const roles = response?.data?.roles;
            setAuth({ userEmail, userPassword, roles, accessToken });
            setUserEmail('');
            setUserPassword('');
            setSuccess(true);//
            // navigate(from, { replace: true });
        } catch (err) {
            if (!err?.response) {
                setErrMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrMsg('Missing User Email or User Password');
            } else if (err.response?.status === 401) {
                setErrMsg('Unauthorized');
            } else {
                setErrMsg('Login Failed');
            }
            setSuccess(false);
            errRef.current.focus();
        }
    }

    return (
        <>
            {success ? (//
                <div>
                    <h1>You are logged in!</h1>
                    {/* <ToDo /> */}
                    <br />
                    <p>
                        <Link to="/todo" className='homeLink'>Go to Home</Link>
                    </p>
                </div>
            ) : (
                <section>
                    <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>
                    <h1>Sign In</h1>
                    <form onSubmit={handleSubmit}>
                        <label htmlFor="userEmail">User Email:</label>
                        <input
                            type="text"
                            id="userEmail"
                            ref={userRef}
                            autoComplete="off"
                            onChange={(e) => setUserEmail(e.target.value)}
                            value={userEmail}
                            required
                        />

                        <label htmlFor="userPassword">User Password:</label>
                        <input
                            type="password"
                            id="userPassword"
                            onChange={(e) => setUserPassword(e.target.value)}
                            value={userPassword}
                            required
                        />
                        <button>Sign In</button>
                    </form>
                    <p>
                        Need an Account?<br />
                        <span className="line">
                            <Link to="/register">Sign Up</Link>
                        </span>
                    </p>
                </section>
            )}
        </>
    )
}

export default Login
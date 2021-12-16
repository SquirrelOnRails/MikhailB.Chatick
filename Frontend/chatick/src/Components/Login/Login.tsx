import React, { useState } from 'react';
import Settings from '../../Settings/Settings';
import IToken from '../../Interfaces/IToken';
import { useNavigate } from "react-router-dom";
import './style.css';

interface ILoginUser { usernameCred: string, passwordCred: string }
const loginUser = async ({ usernameCred, passwordCred }: ILoginUser) => {
  let token:IToken = { Value: "test123", ValidTo: new Date("2012.12.12"), UID: "FAKEUID" };
  return token;
  // axios
  // return fetch(`http://${Settings.server.http.host}:${Settings.server.http.port}}/api/user/login`, {
  //   method: 'POST',
  //   headers: {
  //     'Content-Type': 'application/json'
  //   },
  //   body: JSON.stringify({ username: usernameCred, password: passwordCred })
  // })
  //   .then(data => data.json())
}

interface ILogin { setToken: (token: IToken) => void }
const Login:React.FC<ILogin> = ({ setToken }) => {
  let navigate = useNavigate();

  const [username, setUserName] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const onLoginSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const tokenData = await loginUser({ 
      usernameCred: username,
      passwordCred: password
    });
    setToken(tokenData);
    navigate('/');
  }

  return (
    <div className="login-wrapper">
      <h1>Please Log In</h1>
      <form onSubmit={onLoginSubmit}>
        <label>
          <p>Username</p>
          <input type="text" onChange={e => setUserName(e.target.value)} />
        </label>
        <label>
          <p>Password</p>
          <input type="password" onChange={e => setPassword(e.target.value)} />
        </label>
        <div>
          <button type="submit">Submit</button>
        </div>
      </form>
    </div>
  )
}

export default Login;
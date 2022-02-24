import React, {useState} from 'react';
import Settings from '../../Settings/Settings';
import IToken from '../../Interfaces/IToken';
import {useNavigate} from 'react-router-dom';

interface IRegisterUser {
  usernameCred: string;
  emailCred: string;
  passwordCred: string;
}
const registerUser = async ({
  usernameCred,
  emailCred,
  passwordCred,
}: IRegisterUser) => {
  return fetch(
    `http://${Settings.server.http.host}:${Settings.server.http.port}}/api/auth/Register`,
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        username: usernameCred,
        email: emailCred,
        password: passwordCred,
      }),
    }
  ).then(data => data.json());
};

interface IRegister {
  setToken: (token: IToken) => void;
}
const Register: React.FC<IRegister> = ({setToken}) => {
  const navigate = useNavigate();

  const [username, setUsername] = useState<string>('');
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');

  const onRegisterSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const tokenData = await registerUser({
      usernameCred: username,
      emailCred: email,
      passwordCred: password,
    });
    setToken(tokenData);
    navigate('/');
  };

  const handleLogin = () => {
    navigate('/login');
  };

  return (
    <div className="login-wrapper">
      <h1>Create new account</h1>
      <form onSubmit={onRegisterSubmit}>
        <label>
          <p>Username</p>
          <input type="text" onChange={e => setUsername(e.target.value)} />
        </label>
        <label>
          <p>Email</p>
          <input type="text" onChange={e => setEmail(e.target.value)} />
        </label>
        <label>
          <p>Password</p>
          <input type="password" onChange={e => setPassword(e.target.value)} />
        </label>
        <div>
          <button type="submit">Submit</button>
        </div>
        <div>
          <button type="button" onClick={handleLogin}>
            I have an account
          </button>
        </div>
      </form>
    </div>
  );
};

export default Register;

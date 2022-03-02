import React, {useState} from 'react';
import IToken from '../../Interfaces/IToken';
import {POST} from '../../api/common/apiCaller';
import {useNavigate} from 'react-router-dom';
import {Form, Button, Container} from 'react-bootstrap';
import {useDispatch} from 'react-redux';

interface IRegisterUser {
  usernameCred: string;
  emailCred: string;
  passwordCred: string;
}
const registerUser = async ({
  usernameCred,
  emailCred,
  passwordCred,
}: IRegisterUser): Promise<IToken> => {
  return POST(
    'api/auth/Register',
    JSON.stringify({
      username: usernameCred,
      email: emailCred,
      password: passwordCred,
    })
  )
    .then(data => data.token)
    .catch(err => {
      console.log(err);
      alert(err); // TODO обработать
    });
};

interface IRegister {
  setToken: (token: IToken) => void;
}
export const Register: React.FC<IRegister> = ({setToken}) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

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
    if (tokenData?.value) {
      localStorage.setItem('token', JSON.stringify(tokenData));
      dispatch(setToken(tokenData));
      navigate('/');
    }
  };

  const handleLogin = () => {
    navigate('/login');
  };

  return (
    <Container className="col-sm-8 col-lg-4 justify-content-md-center">
      <Form onSubmit={onRegisterSubmit}>
        <Form.Group className="mb-3" controlId="formBasicUsername">
          <Form.Label>Username</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter username"
            onChange={e => setUsername(e.target.value)}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control
            type="email"
            placeholder="Enter email"
            onChange={e => setEmail(e.target.value)}
          />
          <Form.Text className="text-muted">
            We'll never share your email with anyone else.
          </Form.Text>
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            onChange={e => setPassword(e.target.value)}
          />
        </Form.Group>

        <Button variant="primary" type="submit">
          Submit
        </Button>

        <Button variant="link" type="button" onClick={handleLogin}>
          I have an account
        </Button>
      </Form>
    </Container>
  );
};

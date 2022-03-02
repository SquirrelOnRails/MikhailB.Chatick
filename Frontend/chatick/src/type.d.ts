import {IUser} from './Interfaces/IUser';

type UserState = {
  users: IUser[];
};

type UserAction = {
  type: string;
  user: IUser;
};

type DispatchType = (args: UserAction) => UserAction;

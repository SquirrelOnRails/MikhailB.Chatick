import {createSlice} from '@reduxjs/toolkit';
import {GetUserDisplayInfo} from '../../api/user';
import {IUser} from '../../Interfaces/IUser';

const userSlice = createSlice({
  name: 'user',
  initialState: {
    loading: false,
    data: null,
  },
  reducers: {
    loading: state => {
      state.loading = true;
    },
    user: (state, action) => {
      state.loading = false;
      state.data = action.payload;
    },
  },
});

const {user, loading} = userSlice.actions;

export const loadUser = (dispatch: any) => {
  dispatch(loading());

  const userId = ''; // TODO: получить userId из сторейджа/стейта
  const promises = [GetUserDisplayInfo(userId)];

  return Promise.all(promises).then(list => {
    dispatch(user(list[0]));
  });
};

export const selectUser = (state: {user: IUser}) => state.user;

export default userSlice.reducer;

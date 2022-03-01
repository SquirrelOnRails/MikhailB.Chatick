import {createSlice} from '@reduxjs/toolkit';

const tokenSlice = createSlice({
  name: 'token',
  initialState: {
    token: {
      value: '',
      uid: '',
    },
  },
  reducers: {
    setToken: (state, action) => {
      state.token = action.payload;
    },
  },
});

export const {setToken} = tokenSlice.actions;

export const selectToken = (state: any) => state.token;

export default tokenSlice.reducer;

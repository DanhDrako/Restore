import { createSlice } from '@reduxjs/toolkit';

export type CounterState = {
  data: number;
};

const initialState: CounterState = {
  data: 42
};

export const counterSlice = createSlice({
  name: 'counter',
  initialState: {
    value: initialState.data
  },
  reducers: {
    increment: (state, action) => {
      state.value += action.payload;
    },
    decrement: (state, action) => {
      state.value -= action.payload;
    }
  }
});

export const { increment, decrement } = counterSlice.actions;

export const incrementLegacy = (amount: number = 1) => {
  return {
    type: 'increment',
    payload: amount
  };
};

export const decrementLegacy = (amount: number = 1) => {
  return {
    type: 'decrement',
    payload: amount
  };
};

export default function counterReducer(
  state = initialState,
  action: { type: string; payload: number }
) {
  switch (action.type) {
    case 'increment':
      return { ...state, data: state.data + action.payload };
    case 'decrement':
      return { ...state, data: state.data - action.payload };
    default:
      return state;
  }
}

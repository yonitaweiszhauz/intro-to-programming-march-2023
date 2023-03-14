import { createReducer, on } from '@ngrx/store';
import { ValidCountByValues } from '../../models';
import { counterEvents } from '../actions/counter.actions';

export interface CounterState {
  current: number; // for strong typing
  by: ValidCountByValues;
}

const initialState: CounterState = {
  current: 0,
  by: 1,
};

// return a new state given the current state and action
export const reducer = createReducer(
  initialState,
  on(counterEvents.incrementButtonClicked, (currentState: CounterState) => ({
    ...currentState,
    current: currentState.current + currentState.by,
  })),
  on(counterEvents.decrementButtonClicked, (s) => ({
    ...s,
    current: s.current - s.by,
  })),
  on(counterEvents.resetButtonClicked, () => initialState),
  on(counterEvents.countBySet, (s, a) => ({ ...s, by: a.by })),
);

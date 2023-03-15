import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromCounter from './reducers/counter.reducer';

export const featureName = 'counterFeature';
// eslint-disable-next-line @typescript-eslint/no-empty-interface
export interface CounterState {
  counter: fromCounter.CounterState;
}

export const reducers: ActionReducerMap<CounterState> = {
  counter: fromCounter.reducer,
};

// step 1 - how we get the feature
const selectFeature = createFeatureSelector<CounterState>(featureName);

// step 2 - select correct branch of feature
export const selectCounterBranch = createSelector(
  selectFeature,
  (f) => f.counter, // f is the feature
);

export const selectCounterCurrent = createSelector(
  selectCounterBranch,
  (b) => b.current,
);

export const selectCounterResetDisabled = createSelector(
  selectCounterCurrent,
  (c) => c === 0,
);

export const selectCountingBy = createSelector(
  selectCounterBranch,
  (b) => b.by,
);

import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  select,
} from '@ngrx/store';
import * as fromItems from './reducers/items.reducer';
import * as fromErrors from './reducers/errors.reducer';
export const featureName = 'learningFeature';

export interface LearningState {
  items: fromItems.ItemsState;
  errors: fromErrors.ErrorsState;
}

export const reducers: ActionReducerMap<LearningState> = {
  items: fromItems.reducer,
  errors: fromErrors.reducer,
};

// 1. Feature Selector
const selectFeature = createFeatureSelector<LearningState>(featureName);

// 2. Selection Per Branch
const selectItemsBranch = createSelector(selectFeature, (f) => f.items);
const selectErrorsBranch = createSelector(selectFeature, (f) => f.errors);

// 3. Helpers
export const { selectAll: selectItemsEntitiesArray } =
  fromItems.adapter.getSelectors(selectItemsBranch);

// 4. Components
// ItemsEntity[] - using the selectItemsEntitiesArray from above.
export const selectHasError = createSelector(
  selectErrorsBranch,
  (b) => b.hasError,
);
export const selectErrorMessage = createSelector(
  selectErrorsBranch,
  (b) => b.errorMessage,
);

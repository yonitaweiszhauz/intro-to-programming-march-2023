// Events
import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { ItemEntityRequestModel } from '../../models/items.models';
import { ItemEntity } from '../reducers/items.reducer';

// Commands
export const itemsEvents = createActionGroup({
  source: '[Learning] Events',
  events: {
    'Item Creation Requested': props<{ payload: ItemEntityRequestModel }>(),
  },
});

export const itemsCommands = createActionGroup({
  source: '[Learning] Items Commands',
  events: {
    'Load The Items': emptyProps(),
  },
});

// Documents

export const itemsDocuments = createActionGroup({
  source: '[Learning] Items Documents',
  events: {
    items: props<{ payload: ItemEntity[] }>(),
    item: props<{ payload: ItemEntity }>(),
  },
});

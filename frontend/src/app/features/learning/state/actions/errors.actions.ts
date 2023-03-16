import { createActionGroup, emptyProps, props } from '@ngrx/store';

export const errorsEvents = createActionGroup({
  source: '[Learning] Error Events',
  events: {
    'Error Happened': props<{ message: string; innerError: any }>(),
    'Error Cleared': emptyProps(),
  },
});

import { createActionGroup, props } from '@ngrx/store';

export const errorsEvents = createActionGroup({
  source: '[Learning] Error Events',
  events: {
    'Error Happened': props<{ message: string }>(),
  },
});

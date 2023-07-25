import { Employee } from './employee';

describe('Employee', () => {
  it('Должен создать инстанс', () => {
    expect(new Employee()).toBeTruthy();
  });
});
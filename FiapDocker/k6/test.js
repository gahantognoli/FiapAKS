import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  scenarios: {
constant_10_RPS:
{
executor: 'constant-arrival-rate',
      rate: 1000, 
      timeUnit: '1s',
      duration: '1m', 
      preAllocatedVUs: 10,
      maxVUs: 20,
    },
  },
};


export default function () {
    http.get('http://localhost:7001/previsaoTempo/condicoes-atuais');
    sleep(1);
}

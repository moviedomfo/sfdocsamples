
var amqp = require('amqplib/callback_api');
import * as faker from 'faker';
var colors = require("colors");
import {v4 as uuidv4} from 'uuid'
import { Person } from './model';


var messagesAmount = 2;
var cron = require("node-cron");
// En el direct la cola no importa, al igual que en el fanout
const exchangeName = process.env.EXCHANGE || 'alersDirectExchange'; 
const exchangeType = 'direct'



export class Publisher {
  constructor() {}

  public async Start() {
    // leemos los parametros o args
    const args = process.argv.slice(2);
    // routingKey
    const alertSeverity = args.length > 0 ? args[2] : "red";

    console.log(
      colors.blue(
        `------------------Direct exchange publisher rutingKey = "${alertSeverity}" --------------------`
      )
    );

    setInterval(async () => {
      console.log(colors.blue(`---->Sending--------------- "${alertSeverity}"-----`));
      await this.DoWork(alertSeverity) ;
    }, 3000);
  }
  public async DoWork(alertSeverity): Promise<void> {
    amqp.connect("amqp://localhost", function (error0, connection) {
      if (error0) {
        throw error0;
      }
      connection.createChannel(function (error1, channel) {
        if (error1) {
          throw error1;
        }

        channel.assertExchange(exchangeName, exchangeType, {
          durable: false, // by default is true
        });

        while (messagesAmount--) {
          const person = Publisher.generatePerson();
       
            const sent = channel.publish( exchangeName,alertSeverity, // ruteo
              Buffer.from(JSON.stringify(person)),
              {
                persistent: true,
              }
            );
  
            sent
              ? console.log(
                  `Sent to "${exchangeName}" exchange "${exchangeName}" `,  person.GetFullName())
                : 
                console.log(`Fails sending message to "${exchangeName}" exchange `, person.GetFullName());
                //connection.close();
                //process.exit(0);
              
          
           
      
        }
        Publisher.exitAfterSend();
      });

      setTimeout(function () {
        connection.close();
        //process.exit(0);
      }, 500);
    });
  }

  public static generatePerson(): Person {
    let p: Person = new Person();
    p.Id = uuidv4();
    p.FirstName = faker.name.firstName();
    p.Lastname = faker.name.lastName();

    return p;
  }




static async   exitAfterSend() {

  console.log(`Exit After Send`);
    await this.sleep(messagesAmount * 500 * 1.2)

    process.exit(0)
}
static sleep(ms) {
  return new Promise((resolve) => {
      setTimeout(resolve, ms)
  })
}
}

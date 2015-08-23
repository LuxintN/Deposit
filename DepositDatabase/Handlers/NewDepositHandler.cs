﻿using System;
using DepositDatabase.Model;

namespace DepositDatabase.Handlers
{
    public class NewDepositHandler : DomainLogic.Handlers.INewDepositHandler
    {
        private readonly DepositEntities dbContext;

        public NewDepositHandler()
        {
            dbContext = new DepositEntities();
        }

        public DomainLogic.Model.Cards GetCardById(string id)
        {
            return CardsData.GetCardById(id, dbContext).ToDomainLogic();
        }

        public DomainLogic.Model.Currencies GetCurrencyByDepositTermsId(byte termsId)
        {
            return DepositTermsData.GetTermsById(termsId, dbContext).Currencies.ToDomainLogic();
        }

        public DomainLogic.Model.Deposits CreateNewDeposit(decimal depositAmount, byte wayOfAccumulationId, string userId, byte termsId, string cardId)
        {
            var depositTerms = DepositTermsData.GetTermsById(termsId, dbContext);

            var newDeposit = new Deposits()
            {
                UserOwnerId = userId,
                InitialAmount = depositAmount,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(depositTerms.Months),
                Balance = depositAmount,
                DepositWaysOfAccumulation = DepositWaysOfAccumulationData.GetWayById(wayOfAccumulationId, dbContext),
                Cards = CardsData.GetCardById(cardId, dbContext),
                DepositTerms = depositTerms,
                DepositStates = DepositStatesData.GetStateByName("Opened", dbContext)
            };

            DepositsData.AddNewDepositToDbContext(newDeposit, dbContext);

            return newDeposit.ToDomainLogic();
        }

        public void DecreaseCardBalanceByDepositAmount(decimal depositAmount, string cardId)
        {
            var card = CardsData.GetCardById(cardId, dbContext);
            card.Balance -= depositAmount;
        }

        public void AddCardHistoryRecord(string cardId, string cardHistoryDescription)
        {
            var card = CardsData.GetCardById(cardId, dbContext);
            CardHistoryData.AddRecordToDbContext(card, cardHistoryDescription, dbContext);
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                if (dbContext.HasUnsavedChanges())
                {
                    dbContext.SaveChanges();
                }

                dbContext.Dispose();
            }
        }
    }
}
